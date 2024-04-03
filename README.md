This is a Full-Stack Mobile App - You can adopt pets; Will be shown pets ordered by age, by popularity, by gender and by breed; It contains a user JWT factory, custom Message Handler and Trust Provider. 

The data is fetched via API from a DB.

The application is made in .NET MAUI with C# and XAML



NOTES:
As of 23/03/2024, the dev tunnel still doesn't work, so I'm using localhost => Will have to use local images, because localhost doesn't serve images.

From 25/03/2024 To 03/04/2024, a lot of major and minor issues fixed.

As of 03/04/2024, the app cannot load photos because they are too large (an issue it never had before with the same quality and quantity of photos). No matter how much I compress them, Java.Lang.Runtime spews out "Canvas trying to draw too large bitmap".
Also, one of the pages doesn't want to load its content, although the back-end shows 200 status code, the data that must be shown is parsed without an issue, but when it comes to the front-end it just doesn't want to load. (Interestingly enough, I used the same UI I use on a different page and the content loaded, but after that it just disappeared. The API is serving the correct data without error, numerous hours of debugging the app's back-end didn't amount to something and the front-end just doesn't work. 

CONCLUSION:

POSITIVES:
I gained a lot of practical experience in creating User functionalities for mobile apps (Login/Register, User Credibility Checks, Logged-In User Content, Anonymous User Content), Exception Handling, API experience, MS SQL Experience, generating JWT, safe data transfer between App and DB via API.

NEGATIVES:
I've heard that .NET MAUI has issues, now I can attest to those issues. The experience I got from this project is that of debugging a new issue everyday and fixing it, only for a new one to take its place -> patience. Adaptability is another one, given how wildy different each issue was. I had to create a "Dangerous" Trust Provider for the app to work in Development. I had to reinstall the Android Emulator multiple times, because it wouldn't load at all. I had to re-do my DB migrations, because the original one was creating major issues. 
