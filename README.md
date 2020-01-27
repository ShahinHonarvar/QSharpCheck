# QSharpCheck
QSharpCheck is a property-based testing framework for Q# programs.
It is a generative-testing library (similar to QuickCheck for Haskell and Scalacheck for Scala) to randomise inputs and perform statistical check to test the defined properties.
QSharpCheck  is developed in C#;  however, we expect that its concept can be applied to other quantum programming languages.
Below we provide a brief description of the structure of our package and also provide some instructions on how to install and use it.

To test a program or an operation, initially a test script requires to be written. The file must be named "test.txt" and be written as follows:

At the first line, a test property is given a name. E.g.: Transform_Property;

At the next line, parameters used for test case generation, execution, and analysis are provided and in order, they are the number of concrete test-cases to be generated from the property (i.e., instantiation of variables used in the property); the statistical confidence level for the property to hold (in test analysis); and the number of experiments and measurements (test executions) for each concrete test case to obtain the data for statistical tests. Note that the first and the last parameters are semantically different: the first parameter refers to the number of generated concrete test cases from each abstract property and the last parameter refers to the number of experiments and measurements performed for each concrete test case. For instance, (10, 99, 500, 300);

The input data type of the test followed by a given interval is indicated at the next line as precondition for the test. It is necessary to put the precondition inside { }. E.g.: {q : Qubit (36,72)(0,360)};

In the following line, the name of the Q# process or program under test is provided. E.g: TransformState(q);

In the last line, the corresponding built-in assertion as the precondition of the test is specified. It is required to put the postcondition inside \[ \]. E.g: \[AssertTransformed (q , (108,144)(0,360))\];

Any blank line between the written lines of the test file is irrelevant, also any number of white spaces between the characters of each line is meaningless. As an optional notation, each line can be also followed by a semicolon.

When the test file is prepared, the "Tool" subfolder of "QSharpCheck 1.0" should be downloaded and then "test.txt" and the program under test must be placed in the same folder.

Inside the terminal, the user should "cd" to the folder and then execute "dotnet run". Ultimately, the test outcome will be displayed. Following is an example of a test file written in compliance with the syntax grammer as described:

Transform_Property;
(10, 99, 500, 300);

{q : Qubit (36,72)(0,360)};

TransformState(q);

\[AssertTransformed (q, (108,144) (0,360))\];
