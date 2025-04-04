
# Number To Word Converter

The NumberToWord Converter is an ASP.NET Core Web API solution I developed to convert numerical values into their corresponding word representations. I have built this with Clean Architecture principles in mind, wherein the solution separates concerns into following projects:

- **NumberToWordConverter.API:**  
  This project contains the Web API controllers, global exception handling, and middleware configuration. It serves as the entry point for HTTP requests.

- **NumberToWordConverter.Application:**  
  This project contains the core business logic, including the number-to-word conversion service. This layer encapsulates the main functionality and can be reused across different types of clients.

- **NumberToWordsConverter.Helpers:**  
  Provides utility methods and extension functions.

- **NumberToWordsConverter.Tests:**  
  Contains unit tests that ensure the correctness and reliability of the conversion logic.

The solution also features dependency injection, configuration via JSON, making it a robust, scalable, and testable application for converting numbers into words.

---




## Authors

- [@govindarun](https://www.github.com/govindarun)


## API Reference

### NumberToWordConverter.API
### Version: 1.0

### /NumberToWord

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| inputNumber | query |  | No | double |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | OK |


## Demo

Insert gif or link to demo


## Installation

Run the project NumberToWordConverter.API using Visual Studio with .Net 8 installed. Go to the url https://localhost:44351/Index.html
    
## Documentation

Refer the file DesignRationale.docx file in the Solution Items


## Tech Stack

**Client:** HTML, CSS, JavaScript

**Server:** Asp .Net Core Web API, .Net 8

