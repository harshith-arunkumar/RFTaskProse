# RFTaskProse

# ERROR NOTE: 
There is a slight continuation error in the client file Program.cs while taking input, so after you press option "1", and give your input, 
you will get your answer. However to try out a new sample, please exit and restart the program again! Did not have time to fix this :)

# USAGE:
Download the repo and open "prose.soln" in Visual Studio 2017. The folder "ProseTutorial" contains my grammar, semantics and witness function code files.

Code repository containing my assignment content for the RF task on PROSE.

# Problem Statement: 
Your goal is to take a list of positive integers and check if you can operate on them to get a desired value.
The only operators you have are Add, Multiply, Divide and ElementAt. Also, we do not care if all the numbers in the list are used or not; 
and a number can be used multiple times as well. As an example, say you have {[1, 2, 3, 4], 7} then your output can consists of programs like :

1. Add(Element(2), Mul(Element(1), Element(1))
2. Add(Element(2), Element(3))
You need to design a DSL for this, write the Semantics and Witness functions.

# Menu: 
Select one of the options:
1. 1 - provide new example
3. 3 - exit


# NOTE:
1. Please follow the format given as {[1, 2, 3, 4], 7} including exact whitespaces.
2. Since our goal above is to just produce the programs that lead to that desired value, in the above menu option 1 is sufficient to provide top Programs.
3. If program list is empty, we conclude that the desired value using the given operations is not possible.

# DESIGN CHOICES MADE:

1. Since need for ranking of programs wasn't specified, in the Ranking Score file, only 1 was returned everywhere.
2. Top 50 programs are returned, however this can be changed in Program.Cs.
