# QSharpCheck
QSharpCheck is a property-based testing framework of quantum programs in Q#. It is a generative-testing library (similar to QuickCheck for Haskell and Scalacheck for Scala) to randomise inputs and perform statistical check to test the defined properties.
QSharpCheck is developed in C#; however, we expect that its concept can be applied to other quantum programming languages. The corresponding research paper is accessible via:\
https://bit.ly/3e3SzSr \
Below we provide a brief description of the structure of our package and also provide some instructions on how to install and use it.


## Requirements
The required operating system is either Linux or macOS. Also, .NET Core SDK 3.0 or higher should have been installed to run the test. The latest version is available at:\
https://dotnet.microsoft.com/download \
In addition, installation of the Microsoft Quantum Development Kit (QDK) is required. It is available for download from:\
https://docs.microsoft.com/en-us/quantum/install-guide/ \
It is recommended to regularly update the Microsoft Quantum Development Kit (QDK). The instructions are available at:\
https://docs.microsoft.com/en-us/quantum/install-guide/update?view=qsharp-preview


## How to write the test script
To test a program or an operation, initially it is required to write a test file complied with the QSharpCheck grammer. The file can have any arbitrary name however, its contents should be as follows:\
At the first line, a test property is given a name. E.g.: `Transform_Property;`\
At the next line, parameters used for test case generation, execution, and analysis are provided and in order, they are the number of concrete test-cases to be generated from the property (i.e. instantiation of variables used in the property); the statistical confidence level for the property to hold (in test analysis); and the number of experiments and measurements (test executions) for each concrete test case to obtain the data for statistical tests. Note that the first and the last parameters are semantically different: the first parameter refers to the number of generated concrete test cases from each abstract property and the last parameter refers to the number of experiments and measurements performed for each concrete test case. For instance, `(10, 99, 350, 300);`\
The input data type of the test followed by a given interval is indicated at the next line as a precondition for the test. It is necessary to put the precondition inside `{ }`. E.g.: `{q : Qubit (36,72)(0,360)};`\
In the following line, the name of the Q# process or program under test is provided. E.g: `TransformState(q);`\
In the last line, the corresponding built-in assertion as the precondition of the test is specified. It is required to put the postcondition inside `[ ]`. E.g: `[AssertTransformed (q , (108,144)(0,360))];`\
Any blank line between the written lines of the test file is irrelevant, also any number of white spaces between the characters of each line is meaningless. As an optional notation, each line can be also followed by a semicolon.\
Following is an example of a test file written in compliance with the syntax grammer as described:
```
Transform_Property;

(10, 99, 350, 300);

{q : Qubit (36,72)(0,360)};

TransformState(q);

[AssertTransformed (q, (108,144) (0,360))];
```


## How to run the test
When the test script and the program to be tested are prepared, they have to be placed in the current folder, which is the QsharpCheck folder.
Inside the terminal, the user should "cd" to the QsharpCheck folder and then execute:\
`./run <test file name including its extension>`\
Susequently, the new build is created and "TestExecutionEngine.cs" and "TestQSharpOperation.qs" will be generated in the QSharpCheck namespace. Ultimately, the test outcome will be displayed. The following report is an example of the test verdict when all tests pass:
```
╒═══════════════════════════════════════════════════════╕
  Testing "Transformation_Property"
  
  Number of test cases:     10
  Confidence level:         99
  Number of measurements:   350
  Number of experiments:    300
  
  AssertTransformation was true in all test cases.
  Passed 10 tests.
╘═══════════════════════════════════════════════════════╛

 Test execution elapsed time is 00:03:21.320
```
And the following outcome is an example of the test verdict when a test fails:
```
╒═══════════════════════════════════════════════════════╕
  Testing "Transformation_Property"
  
  Number of test cases:     10
  Confidence level:         99
  Number of measurements:   350
  Number of experiments:    300
  
  After 1 test, AssertTeleported was falsified when:
  θ = 85.4711328868154 and φ = 31.8481939620563
╘═══════════════════════════════════════════════════════╛

 Test execution elapsed time is 00:00:20.837
 ```
