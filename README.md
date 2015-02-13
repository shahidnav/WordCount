# WordCount
## Setting up the app
Enter the path to your text file in the App.config under the appSettings section with a key of "completeFilePathToTextFile"
### Example:
```
  <appSettings>
    <add key="completeFilePathToTextFile" value="R:\\WordCount\\dummy.txt"/>
  </appSettings>
```
## Running the app
Then simply build and run the console app exe
Given an input file containing:
"This is just a sample line appended to create a big file.. "
#### Sample Output
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
