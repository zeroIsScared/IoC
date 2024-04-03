What code smells did you see?
-rigidity
-fragility
-immobility
-needless complexity
-needless repetition
-opacity

What problems do you think the speaker class has?
-It has a large register method that is responsible for more than one operation;
-It is using a lot of negative conditional
-It is using a lot of nesting, which leads to reduced readability and increased complexity. It is also making it hard to test and reuse.

Which clean code principles (or general programming principles) did it violate?
-the single responsibility principle 
-the Open-Close Principle

What refactoring techniques did you use?
-improved readability and reduced complexity by eliminating unnecessary nesting and renaming the variables with undescriptive names;
-reduced complexity and maintainability by splitting the large Register method into several small ones and by adding an interface and a new class;
