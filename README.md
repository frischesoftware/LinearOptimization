Linear Optimization
-------------------

Remember your class on linear optimization? 

"A business makes 2 products. Each product requires different amounts of 3 ingredients which are of limited supply. Both products yield a specific profit, and there's an overall constraint on the factory capacity. What's the ideal combination of products to make?"

That was roughly the excercise we had to solve in class, and that was it. The simplex algorithm that we used was too complicated to be taught for real, so we were just expected to memorize the steps and apply it.

Oh and we briefly heard that out there, aparently people were using this for  [real](https://en.wikipedia.org/wiki/Operations_research#Problems_addressed). But we didn't go into any of that, and the pen-and-paper simplex method wouldn't be useful for that anyway.

This is of course unacceptable, so I made linear-optimization.com

Using the [Microsoft Solver Foundation] (http://msdn.microsoft.com/en-us/library/ff524509%28v=vs.93%29.aspx) (deprecated, so for the next project I might be with [Frontline Solver](http://www.solver.com/)) I randomly create interesting linear optimization problems for various problem types and complexity/difficulty levels. The user may try to solve and enter their answer and get a little feedback as well.

Notes: 
- unless you need it for class, skip the simplex algorithm and use the Solver that comes with Excel or Open Office Calc
- "interesting problem" means that a solution is likely avoid the trivial solution (e.g. 100 of A, 0 of B and 0 of C) in favour of a solution that cannot be found intuitively or by trial-and-error.
- currently supported problem types are the standard production planning problem (see first paragraph) and the [Travelling Salesman Problem](https://en.wikipedia.org/wiki/Travelling_salesman_problem). Honestly, the later one is probably not so easy to formulate either Simplex or Solver, so don't hesitate to check the tutorial or search around the web.
- 


 
