<h1>CodedUITestApplication</h1>
<p>
    This project was created with Visual Studio 2017 Enterprise Edition.
</p>
<p>
    This project will be used to demonstrate Coded UI tests.
	Coded UI requires Visual Studio 2017 Enterprise Edition to run and will not build in a Pro or Community Edition
</p> 
<h3>How to use</h3>
<p>
	Build the solution to see the tests in the test explorer.
</p>
<p>
	To run the WebTest_TestForm and WebTest_Selenium_TestForm test, first run the CodedUITestApplication.Web without debugging. 
	Next start the test from the Test Explorer window.
</p>
<p>
	To run the Test_Windows_Calculator test, make sure that path to calc.exe is vlid for your machine.
	Next start the test from the Test Explorer window. This test was written for the calculator on a Windows 2012 server with english locale and may not work on other locales or with the newer implementation of windows calculator for Windows 10.
</p>
<p>
	To run the Test_WPF_Addition test, make sure to build the CodedUITestApplication.WPF in debug mode. 
	Next run the test from the Test Explorer window.
</p>
<h3>Extra note on running Selenium tests</h3>
<p>
The Coded UI framework still uses TestSettings files and runs from a seperate TestResults/Out directory in your solution folder. The newer MSTest v2 adapter no longer supports this method and runs in from the files in the bin folder. To see the Selenium tests working with the default MSTest V2 framework please see my <a href="https://github.com/SamanthaNeilen/WebDriverTestApplication" target="">WebDriverTestApplication repository</a>.

</p>
		
