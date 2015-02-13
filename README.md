# WordCount
## Changing the default configuration
 - Enter the path to your text file in the App.config under the appSettings section with a key of "completeFilePathToTextFile"
 - Enter the buffer size for the stream reader in the App.config under the appSettings section with a key of "textFileProviderStreamBufferSize", this must be numeric.
### Example:
```
  <appSettings>
    <add key="completeFilePathToTextFile" value="aDirectory\\filename.txt"/>
    <add key="textFileProviderStreamBufferSize" value="4096"/>
  </appSettings>
```
## Running the app
Then simply build and run the console app exe

A dummy file generator batch file is included:

    GenerateLargeDummyText.bat

This will generate a 1GB text file for you.

#### Sample Output
Given an input file containing:

    "This is just a sample line appended to create a big file.. "
    "This is just a sample line appended to create a big file.. "
```
Counting words...
Input data processed in 0.0020013 secs

Distinct words and count:
THIS - 2
IS - 2
JUST - 2
A - 4
SAMPLE - 2
LINE - 2
APPENDED - 2
TO - 2
CREATE - 2
BIG - 2
FILE - 2
```

## Dependencies
**Autofac** - Dependency injection container
**NUnit** - Unit test framework
**Moq** - Mocking frameork
