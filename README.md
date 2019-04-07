1.	Details of applications, framework required to run solution

Asp.net MVC application.
.NET Framework, Visual Studio 


2.	Instructions to install, configure and execute solution
Content from the published folder would be used to deploy the web application in IIS. 
Make sure framework 4.6 is installed as well.


3.	Technical description and explanation of design and programming techniques utilised

Used ASP.NET MVC5, AJAX, jQuery, Html5, Bootstrap, CSS for the web application.
Index view and the output view has been designed using Bootstrap.  

On form submission, values will be passed onto controller via ajax instead of using razor to minimize the reloading of page. The output response would be returned in the form of JSON which will populated in the output modal view.

Added Unity container for injecting dependency in the Index Controller.

Test project created using MS Unit Testing Framework for validating the business layer logic.

 
   
