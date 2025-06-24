# ErikssonSoftware Assignment

## Log Analyzer

This application was created as a blazor web app since I am comfortable working with blazor.

## Approach
I wanted to create something to show good programming habits, apply things I've learned, as well as explain my thought process.

1. I started by creating a simple data model.
2. Second, create an interface to use for our Parser method. This will allow flexibility, customization and easier testing in the future.
3. Then, Implementation of the interface and managing the log file lines.
4. We work with the entries using LINQ, we group by, select and count which is concise, and easy to read. More pleasant and easier than manual loops.
5. Finally put everything together in a home page where you can select which event type you would like displayed.
6. The UI will display a simple table with the occurrences of each event type. Below that, the top 3 messages for that event.

## Assumptions
My assumptions were that we always get a txt file identical to the one provided. The format stays the same, being ([TIMESTAMP] [EVENT_TYPE] [MESSAGE]). Also we just view and work with the data, and thats it, we don't have to save it.

## Limitations
Limitations or things missing from this application are that the parser will just skip lines if not in our format. Theres no graceful way of handling these lines or any type of warning or notication other than to skip. It would be great to implement something for this to at least try to get the line and view it elsewhere.

Also, it only accept .txt files. Input of another file type will not work. 

Theres also no advanced viewing or filtering, just the required implementation and thats it. More could be added to make this a more powerful application to view and analyze logs. And no exporting either, you can view within the browser but you can't save that information displayed

## How to run
Simply run the application, the home page will open under localhost.
The default top 3 messages come from "ERROR". But using the buttons you can select to view them for "INFO" or "WARNING". Click browse, select the log file, and the UI will be updated.

## Documentation
I have created a separate page titled documentation. It can be found on the left bar under Home. I enjoyed and had fun working with this project, so I took a little bit of time to go over my thoughts in more detail.

