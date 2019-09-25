# EasySelectionChatbot
A simple ChatBot which allows an end user to help in selecting from range of available Patient Monitors.
## API Documentation
- Whole API documentation is provided by swagger in a JSON format in the following link  http://localhost:51844/swagger/docs/v1
and a swagger based UI to understand and test the API is in the following link http://localhost:51844/swagger/
- A Major advantage of using swagger is to adapt to changes made to API **The Document update can be performed only by changing the XML comments in the code.**

## Project Brief Introduction
- This project Consists of API which exposes the internal logic of the chatbot
- Chatbot is an interactive machine which keeps asking qusetions based on the previous question's answer and at the end based on the choices made by the end user it displays an item or a set of items filtered.
- All questions given by the chatbot to the end user will be in the form of multiple choice options which may include true or false type as well.

## Technical Details About the project
Project exposes API which are as Follows
1. GET request to fetch the question as well as options(hitting the base url of this get request will yeild first Question), another parameterised overrided form of this rquest takes the previous Question and Option selected by end user and provides next question and options
2. GET request to fetch the Monitors(hitting the base url will provide all available monitors), another parameterised overrided form of this reuest takes the Previous Question and Option Selected to fetch the monitors filtered.
3. POST request to save the details of customers.

### Language and Tools 
1. ASP.NET Web Application (.NET Framework 4.7.2)
2. Microsoft SQL Server 2017 (DB used)

## Coding Standards
Below mentioned are the standards defined for the project
1. Maximum cyclomatic code complexity of a function - 10
2. Maximum lines of code of a function - 25
3. Coverage - 75% (since the inclusions of DB related operations which are not covered in the unit testing)
4. Duplication - 0
eas
