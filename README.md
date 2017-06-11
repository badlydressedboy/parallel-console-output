# Multi Threaded Console Output

A class to allow output from threads in their own line(s) in the console. Great for report progress across Tasks/Threads.

Instead of having multiple threads write to the current line in the console which can be confusing and messy this class allows threads to write to their own console line.

Options allow a thread to output to either a single line that word-wraps or alternatively create new console lines as it goes.

Class includes methods to:
  Output animations for % complete.
  Output elapsed time task has been running. Valuable for testing your code.
  Display working animation of spinning ascii -\|/
  Write new text on same spot or continue along the console line.
 
Options:
  Include persistant header/title text at left of threads console line(s), so you know which line is which thread.
  Word-wrap or overwrite existing line on filling the line.


Demo console application starts multiple tasks that demonstrate how the class can be used. Easy to change options to suit it for your needs.

