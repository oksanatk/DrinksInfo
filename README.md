# DrinksInfo ![C#](https://img.shields.io/badge/C%23-blue.svg)

Simple Console app written in C# that uses HttpClient to get 
data and display 
data about drinks from a free RESTful 
[drinks API](https://www.thecocktaildb.com/api.php)

## ✅ Given Requirements

 - [x] You were hired by restaurant to create a solution for
       their drinks menu.
 - [x] Their drinks menu is provided by an external company. All the
       data about the drinks is in the companies database, accessible
       through an API.
 - [x] Your job is to create a system that allows the restaurant employee
       to pull data from any drink in the database.
 - [x] You don't need SQL here, as you won't be operating the database.
       All you need is to create an user-friendly way to present the
       data to the users (the restaurant employees)
 - [x] When the users open the application, they should be presented with
       the Drinks Category Menu and invited to choose a category.
       Then they'll have the chance to choose a drink
       and see information about it.
 - [x] When the users visualise the drink detail, there shouldn't be
       any properties with empty values

## 🚀 Features

  🔹 Asynchoronous API calls to prevent UI freezing.
  
  🔹 Sprectre.Console Selection Menu helps make selecting a
    drink easy and error-free
    
  🔹 Spectre.Console use of colors to markup drink display

<img src="https://github.com/user-attachments/assets/a52ce9c0-0261-4475-bdaa-980060e31f32" width="200">
<img src="https://github.com/user-attachments/assets/82ea8e0f-5f63-4783-9028-52dc2f7e44d6" width="600">

## 🔥 Challenges / Lessons Learned
  - JSON Drinks objects were nested in a root object of drinks[].
    This created a bit of a challenge in reading it into a Drink
    object. but...
  - A bigger issue was trying to read all of the ingredients
    and their respective measurments into a IngredientMeasures
    Dictionary


## 🌟 Things I Did Well

  ⚡ Each commit was done to a feature-branch in git, and then
    merged or rebased back onto the main branch

## 📌 Areas to Improve

  🔍 Generally, I think I need extra practice with algorithmic
    thinking / practice problems. LINQ is very powerful,
    but I often only understand / figure out how to
    implement it after I've googled or asked ChatGPT. 

## 📚 Resources Used

  🔗[basic use of HttpClient()](https://www.youtube.com/watch?v=Yi-O-HBGPeU)

  🔗ChatGPT and Google

  🔗The C# Academy's [Project Page](https://www.thecsharpacademy.com/project/15/drinks)

  🔗[Tim Corey's Web API Video](https://www.youtube.com/watch?v=vN9NRqv7xmY)

  🔗[Microsoft HttpRequest Docs](https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient)
  
  🔗[README Markdown Guide](https://markdownguide.offshoot.io/cheat-sheet/)
