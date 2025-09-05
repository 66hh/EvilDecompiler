# EvilDecompiler

A simple quickjs decompiler that converts bytecode to JavaScript code by simulating the quickjs stack.

## Core Idea

* Stack Simulation: Use a stack to record tokens during decompilation.
* Characteristic Bytecode: When encountering specific bytecode for assignment or function calls, pop the tokens from the stack, concatenate or compute them, and write the result into JavaScript code.
* Code Generation: Through a series of push and pop operations on the stack, the complete JavaScript statement is generated.

#### Example

```
push_0 // Stack becomes ["0"]
push_1 // Stack becomes ["0", "1"]
add // Stack updates to ["0 + 1"]
put_loc1 // Pop the value from the stack and generate the statement "loc1 = 0 + 1";
```

# Warning
This decompiler is still in an experimental version, please do not use it in production environments.

# License
This software is released under the AGPL3.0.