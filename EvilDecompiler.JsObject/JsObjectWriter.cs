using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;
using EvilDecompiler.JsObject.Utils;

namespace EvilDecompiler.JsObject
{
    public class JsObjectWriter
    {

        Writer writer;

        public JsObjectWriter(Stream stream, Types.Objects.JsObject obj, AtomSet atoms)
        {
            writer = new Writer(stream);

            writer.Write((byte)Types.Objects.JsObject.Version);

            WriteObjectAtoms(atoms);

            WriteObjectRec(obj);
        }

        void WriteObjectAtoms(AtomSet atoms)
        {

            int count = atoms.Atoms.Count;

            writer.WriteLeb128(count - atoms.InternalCount);

            for (int i = 1; i < count + 1; i++)
            {
                JsString? obj = atoms.Get(i);
                if (obj != null && !atoms.IsInternal(i))
                    WriteJsString(obj);
            }
        }

        void WriteJsString(JsString str)
        {
            byte[] value = str.Raw;

            int flag;
            if (str.IsWide)
                flag = (value.Length / 2) << 1 | (str.IsWide ? 1 : 0);
            else
                flag = value.Length << 1 | (str.IsWide ? 1 : 0);

            writer.WriteLeb128(flag);
            writer.Write(value);
        }


        void WriteAtomIdx(AtomIdx idx)
        {
            writer.WriteLeb128(idx.Flag);
        }

        void WriteObjectTag(ObjectTag tag)
        {
            writer.Write((byte)tag);
        }

        void WriteObjectRec(Types.Objects.JsObject obj)
        {

            ObjectTag tag = obj.Tag;

            WriteObjectTag(tag);

            switch (tag)
            {
                case ObjectTag.BC_TAG_NULL:
                case ObjectTag.BC_TAG_UNDEFINED:
                case ObjectTag.BC_TAG_BOOL_FALSE:
                case ObjectTag.BC_TAG_BOOL_TRUE:
                    break;

                case ObjectTag.BC_TAG_INT32:
                    writer.WriteSLeb128(((JsInt32)obj).Value);
                    break;

                case ObjectTag.BC_TAG_FLOAT64:
                    writer.Write(BitConverter.DoubleToInt64Bits(((JsFloat64)obj).Value));
                    break;

                case ObjectTag.BC_TAG_STRING:
                    WriteJsString((JsString)obj);
                    break;

                case ObjectTag.BC_TAG_FUNCTION_BYTECODE:
                    WriteJsFunction((JsFunctionBytecode)obj);
                    break;

                case ObjectTag.BC_TAG_MODULE:
                    WriteJsModule((JsModule)obj);
                    break;

                case ObjectTag.BC_TAG_OBJECT:
                    WriteJsProperties((JsProperties)obj);
                    break;

                // TODO

                default:
                    throw new Exception($"Unsupported Tag! Value: {tag}");
            }
        }

        public void WriteJsProperties(JsProperties obj)
        {
            writer.WriteLeb128(obj.Properties.Count);

            foreach (var prop in obj.Properties)
            {
                WriteAtomIdx(prop.Key);
                WriteObjectRec(prop.Value);
            }
        }

        public void WriteJsModule(JsModule module)
        {
            WriteAtomIdx(module.ModuleName);

            writer.WriteLeb128(module.ReqModules.Count);
            for (int i = 0; i < module.ReqModules.Count; i++)
            {
                ReqModuleEntry entry = module.ReqModules[i];

                WriteAtomIdx(entry.ModuleNames);
            }

            writer.WriteLeb128(module.ModuleExports.Count);
            for (int i = 0; i < module.ModuleExports.Count; i++)
            {
                ExportEntry entry = module.ModuleExports[i];

                writer.Write((byte)entry.Type);

                if (entry.Type == ExportType.JS_EXPORT_TYPE_LOCAL)
                {
                    writer.WriteLeb128(entry.VarIdx);
                }
                else
                {
                    writer.WriteLeb128(entry.ReqModuleIdx);
                    WriteAtomIdx(entry.LocalName);
                }

                WriteAtomIdx(entry.ExportName);
            }

            writer.WriteLeb128(module.ModuleStarExports.Count);
            for(int i = 0;i < module.ModuleStarExports.Count;i++)
            {
                StarExportEntry entry = module.ModuleStarExports[i];

                writer.WriteLeb128(entry.ReqModuleIdx);
            }

            writer.WriteLeb128(module.ModuleImports.Count);
            for (int i = 0; i < module.ModuleImports.Count; i++)
            {
                ImportEntry entry = module.ModuleImports[i];

                writer.WriteLeb128(entry.VarIdx);
                WriteAtomIdx(entry.ImportName);
                writer.WriteLeb128(entry.ReqModuleIdx);
            }

            WriteObjectRec(module.FunctionObject);
        }

        public void WriteJsFunction(JsFunctionBytecode func)
        {
            writer.Write((ushort)func.FunctionFlag.Flag);

            writer.Write((byte)func.JsMode);
            WriteAtomIdx(func.FunctionName);

            writer.WriteLeb128(func.ArgCount);
            writer.WriteLeb128(func.VarCount);
            writer.WriteLeb128(func.DefinedArgCount);
            writer.WriteLeb128(func.StackSize);

            writer.WriteLeb128(func.ClosureVarDefs.Count);
            writer.WriteLeb128(func.CPool.Count);
            writer.WriteLeb128(func.Bytecode.Length);
            writer.WriteLeb128(func.VarDefs.Count);

            for (int i = 0; i < func.VarDefs.Count; i++)
            {
                VarDef def = func.VarDefs[i];

                WriteAtomIdx(def.VarName);
                writer.WriteLeb128(def.ScopeLevel);
                writer.WriteLeb128(def.ScopeNext);
                writer.Write((byte)def.Flag.Flag);
            }

            for (int i = 0; i < func.ClosureVarDefs.Count; i++)
            {
                ClosureVarDef def = func.ClosureVarDefs[i];

                WriteAtomIdx(def.VarName);
                writer.WriteLeb128(def.VarIdx);
                writer.Write((byte)def.Flag.Flag);
            }

            writer.Write(func.Bytecode);

            if (func.DebugInfo != null)
            {
                DebugInfo info = func.DebugInfo;

                WriteAtomIdx(info.FileName);
                writer.WriteLeb128(info.LineNumber);
                writer.WriteLeb128(info.MapData.Length);
                writer.Write(info.MapData);
            }

            for (int i = 0; i < func.CPool.Count; i++)
            {
                WriteObjectRec(func.CPool[i]);
            }
        }

    }
}
