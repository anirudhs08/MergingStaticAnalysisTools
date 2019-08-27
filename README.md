C# case study: Integrate data from different static-analysis tooling


Features of the project:

1)	Configurable – any number of tools can be added from the config file

2)	Intelligent Parsing – Only the relevant portions of the report are extracted from the report to specifically help the developer

3)	Choice of Tools –Tools are chosen such that there is an increase in extent of accuracy covered by Analysis

4)	Auto execution of Test cases – Test cases are always run whenever the solution is built


Static Analysis Tools used

1)	PVS Studio
2)	ReSharper
3)	NDepend


Why did we choose those tools?

1)	PVSStudio has specific messages which help write good quality code
2)	ReSharper has a very comprehensive analysis of the code, including suggestions about how to beautify the code
3)	Ndepend has the most interactive UI among the static analysis tools


A small note on all the tools used:

1)	PVSStudio
	a.	PVS-Studio is a tool for detecting bugs and security weaknesses in the source code of programs
	b.	PVS-Studio performs static code analysis and generates a report that helps a programmer find and fix bugs.

2)	ReSharper
	a.	On-the-fly code quality analysis is available in C#
	b.	Provides an error report in xml

3)	NDepend
	a.	Ndepend is a visual studio extension for static code analysis
	b.	Generates a very interactive html report which will help the user debug various issues.
	
Final output: A merged report
