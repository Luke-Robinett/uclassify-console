# UClassify Console
## A C# console app providing basic access to the UClassify text classification API

***

### Description

This is a C# .NET 5 console app providing basic access to a subset of functionality of the [UClassify text classification API](https://www.uclassify.com/docs).
I'm working on a new Chrome extension that will utilize this API so just wanted to make an easy way for me to explore and test the API. I am in no way affiliated with the developers of the API.

### Running The App

**Note:** You will need to provide your own API key to run the program. You can set up a free account [here](https://www.uclassify.com/account/register) and will be assigned the appropriate key.

1. Clone the repo to the desired location on your system.
2. Build the solution.
3. Create a file called "key.json" in the working directory of the app. By default this should be /uClassify/uClassifyConsoleApp/bin/Debug/net5.0 but adjust accordingly for your environment.
4. Add the following text to the key.json file: `{ "Key": "your-key-here" }`, substituting the value for your UClassify API key, and save the file. The app uses this file to authenticate calls to the UClassify API.
5. You should now be able to run the app.

### Using The App

1. When the app runs you will be prompted for text. Enter the text you want to have analyzed by the API. The text is sent to the API to categorize it.
2. If the API was able to successfully classify your text, you'll be presented with the top three options for the text's primary category, based on confidence of accuracy. Choose the number of the option you want.
3. Based on your selected primary category you'll be presented with the top three subcategories that the API determined are the best fit. These are presented as menu options for future use but nothing happens presently when you select one.

