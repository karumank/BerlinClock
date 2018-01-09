# BerlinClock

Demo available at: http://berlinclock.azurewebsites.com

This application is developed using C#, jQuery, HTML, CSS primarily.

For simplicity, I built this application on top of a template of .Net MVC application provided by Visual Studio.

BerlinClock/Views

Although this folder contains multiple views, I worked only on Home/Index.cshtml and Shared/_Layout.cshtml.

Home/Index.cshtml - This is the VIEW of the application where I have a time picker and UI for Berlin Clock.

I used an external plugin to achieve timepicker animation.

Shared/.Layout.cshtml - This is layout page for all pages. Although I did not change much of default layout styles, I just modified
the menu bar as well as footer.

BerlinClock/Controllers

HomeController - This has ViewResult to render our HTML page also the JsonResult which returns the values of clock units with respect to the input.

BerlinClock/Models

ClockUnit.cs - Used this as a common class to hold properties for all units. (Hours, minutes, seconds) Also contains a static class Units.
FieldColor.cs - Static class to hold colors for display of clock fields.

BerlinClock/Services

ClockService.cs - Created this using Singleton Design Pattern to hold the collection of unit values across the application.




