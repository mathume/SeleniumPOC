Assumptions:
1.) Tests will be compiled and run on Windows platform. I use Windows 10.

Prerequisites: 
1.) Firefox and Chrome - latest versions as by today installed
2.) Use VS 2010 or later for compilation, NUnit for test execution

Issues found:
I wasn't able to handle errors while comunicating with the server
 a.) after clicking Save on a page
 b.) after clicking Apply on restrictions setting dialog of a page
I should handle this in the future, too, but they were not reliably reproduceable.