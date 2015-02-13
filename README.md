# WordCount
Setting up the app
Enter the path to your text file in the App.config under the appSettings section with a key of "completeFilePathToTextFile"

Example:
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
  </startup>
  <appSettings>
    <add key="completeFilePathToTextFile" value="R:\\WordCount\\dummy.txt"/>
  </appSettings>
</configuration>
