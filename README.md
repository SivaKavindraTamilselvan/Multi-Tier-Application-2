## MULTI TIER NOTIFICATION APPLICATION

## STEPS

1. Create Model class Library
2. Create Data Access Library
3. Create Buisness Layer Library
4. Create Presentation Layer (Console App)
5. Add Reference from Model - Data Acess - Buisness Layer - Presentation

Note - .env file found in the presentation layer which contains

- Company Name
- Company PhoneNumber
- Company Name
- Email Password

## Model Library

1. The Models Library will be created for
    - User
    - Company
    - Notification

2. Override of string is created to print the values along with keys.

3. The Model Library is created along with the Custom Exception

    - Email Exception
        - Email validation is checked
        - The message can be passed as the parameter
    - Message Exception 
        - Given condition are made in the exception
        - Check the WhiteSpace
        - Check the Message Length (not greater than 5)
        - SMS Message length should not be greater than 160
    - NotificationNotFoundException 
        - no notification found in the list that is got from the repository
        -empty notification
    - PhoneNumberException 
        - Phone Number is not valid
        - The message is passed as paramter
    - UserNotFoundException 
        - no user found in the list that is got from the repository

Note - Model Library is used for storing the database models and its structure no logical things are done over here.

## Data Access Library

Here The access of database is done where updation,creation and deletion are done and can be accessed only by this layer.

Folder Structure

- Interfaces
    
    - INotificationRepository (additional notification functions)
    - IRepository (common functions for all repos)
    - No IUser created as for now no additional functions are needed

- Repositories

    - AbstractRepository (implement IRepository where common functions are defined)
    - NotificationRepository (create function and other additional function such as userId,service filteration are added for particular repo)
    - UserRepository (create function)
Repositories are created

Interface created for the Repository (Basic CRUD Operations)

- Create
- Delete
- Update
- Get Operation By Id
- Get All User

This interface repository is used for all the Data and an Abstract class can be defined as the functions are similar and no repetation of the code is not needed.

It can be inherited.

AbstractRepository created implementing the IRepository

- Update
- Delete
- Get By iD
- Get All

these functions are similar so no needed to create this for all the model that are created.

- Create function 
    
    - will be different as the attributes and validation are needed to be done which will differ for different for each model. 
    - so the class repository for other models that are inherited can override the function 

Note - The other functions for each repostory can be additionally added if required as per the requirements

The Repositories that are created
- User Repository
- Notification Repository

User Repository

- create function created
- static variable createad for userId
- userId will be increased for each user addition
- all the attributes are validated in the presentation and buisness layer itself

Notification Repository

- GetNotificationByUserIdAndService(int userId,string service)
- GetNotificationByUserId(int userId)
- GetNotificationByService(string service)

All these returns the List here these are additional functions that are added only in the Notification Repo as only used in only notification

These repository are found in the INotificationRepository

**Notification Repository implements both the IRepository and the INotificationRepository** 

## Buisness Layer Library

Folder Structure

- Delegates

    - AddUserDelegate
    - DeleteUserDelegate
    - UpdationUserDelegate
    - NotificationDelegate

- InputsCheck

    - InputCheck (check the inputs validation such as email,phone number,message,id)

- Interfaces

    - INotificationSenderService
    - INotificationService
    - IUserService

- Services

    - Notification
        
        - GetNotificationService (get the notification by userid,service etc)
        - NotificationService (send notification where the type of service is decided and which kind service needed to be called)

    - NotificationSender

        - Email

            - EmailService
            - Email LogService
        
        - SMS

            - SMSService
            - SMS LogService
        
        - Notification.cs file (main file)
        
    - User

        - DelegateService

            - UserAddService.cs
            - UserDeleteService.cs
            - UserUpdateService.cs

        - MainService

            - UserServiceByEmail.cs
            - UserServiceById.cs
            - UserServiceByPhone.cs

        - UserServiceMain.cs

    - Validation

        - EmailValidation.cs
        - MessageValidation.cs
        - PhoneNumberValidation.cs
    

**Delegate**

A delegate in C# is a type-safe function pointer that allows you to reference and call methods dynamically. It essentially treats a method as an object, allowing you to pass a method as a parameter to another method or assign it to a variable

Note - Parameters and return type should be same for the all the functions used in the delegate

- AddUserDelegate

    - Here delegation is used adding the user and then send the notification via the SMS and Email

- DeleteUserDelegate

    - Here delegation is used deleting the user and then send the notification via the SMS and Email

- UpdationUserDelegate

    - Here delegation is used updating the user and then send the notification via the SMS and Email

- NotificationDelegate

    - ValidateTheMessage
    - SendNotification
    - SaveNotification
    - LogNotification

**InputsCheck**

Used to check if the inputs are entered correctly or not.If not again loop will be used untill correct input is entered.

- EmailInput
- SMSInput
- IDInput
- MessageInput

**Interfaces**

- INotificationSenderService.cs (send the message)
- INotificationService.cs (specific for notification list access like get notification by id,service etc)
- IUserService.cs (user crud operation)

**Services**

- Notification

    - SendNotification(message,service,user)
    - PrintNotification()
    - GetNotificationByUserId(userId)
    - GetNotificationById(id)
    - GetNotificationByService(service)
    - GetNotificationByUserIdAndService(userId,service)

- NotificationSender

    Implements the INotificationSenderService

    - ValidationOfMessage()
    - SendNotification()
    - SaveNotification()
    - LogNotification()

    Implemented by delegation for sending the notification

- Email (Override functions) (real email notification sending implemeneted)

    - SendNotification
    - LogNotification

- SMS (Override functions) (only console print)

    - SendNotification
    - LogNotification

- User

    - DelegateService

        - UserAddService.cs
        - UserDeleteService.cs
        - UserUpdateService.cs
        
    - Main Service

        - UserServiceByEmail

            - GetUserByEmail
            - DeleteUserByEmail

        - UserServiceByPhone

            - GetUserByPhone
            - DeleteUserByPhone
        
        - UserServiceById

            - GetUserByEmail
            - DeleteUserByEmail
            - UpdateUserById

        - UserServiceMain.cs

- Validation

    - EmailValidation (Regex)
    - PhoneNumberValidation (Regex)
    - MessageValidation (Conditions)

## Presentation Layer

Roles

- Admin
- User

Admin

- Add User
- Delete User
    - Delete User By UserId
    - Delete User By Phone Number
    - Delete User By Email
- Update The User
- Get The User
    - Get User By Id
    - Get User By Email
    - Get User By PhoneNumber
    - Get All User
- Deliver Message
    - Email
    - SMS   
- Notification
    - Display By UserId
    - Display All
    - Display By Id

User

 - Display the notification by user Id
 - display the notificaiton by service
 - display the notification by userid and service

The files in the project is origanised by the usage of partial class

By cliking the needed options the logic passess

Add User

- Usage of delegates for adding the user to the Dictionary and send notificaiton (both sms and email)
- check the phone number and email id
- no duplicate email user can be added
- phone number duplication for a user is allowed
- a user can have only one email and multiple phone number for registration of user account
- once inputs are checked user added to dictionary
- after creation notification is sent 

Get User

- GetUserById

    - id input is validated (only number greater than 0)
    - Call the user service which implemets the IUserService
    - User or null is returned
    - the service is passed to repo and the data is returned
    - if user null an exception is thrown UserNotFoundExcpetion which is custom created

- GetUserByEmail

    - email is validated (loop untill correct mail is entered)
    - Call the user service which implemets the IUserService
    - User or null is returned
    - the service is passed to repo and the data is returned
    - if user null an exception is thrown UserNotFoundExcpetion which is custom created

- GetUserByPhone

    - phone number is validated (loop untill correct mail is entered)
    - Call the user service which implemets the IUserService
    - User or null is returned
    - the service is passed to repo and the data is returned
    - if user null an exception is thrown UserNotFoundExcpetion which is custom created

- GetAllUser

    - Call the user service which implemets the IUserService
    - User List or empty list is returned
    - the service is passed to repo and the data is returned
    - if user list empty an exception is thrown UserNotFoundExcpetion which is custom created

DisplayTheNotification

- GetNotificationAll

    - Call the notification service which implemets the INotificationService
    - Notification or null is returned
    - the service is passed to repo and the data is returned
    - if notification list is empty an exception is thrown NotificationNotFoundExcpetion which is custom created

- GetNotificationById

    - id input is validated (only number greater than 0)
    - Call the notification service which implemets the INotificationService
    - Notification or null is returned
    - the service is passed to repo and the data is returned
    - if notification null an exception is thrown NotificationNotFoundExcpetion which is custom created

- GetNotificationByUserId

    - userid input is validated (only number greater than 0)
    - even if user deleted history can be printed
    - Call the notification service which implemets the INotificationService
    - Notification List or empty list is returned
    - the service is passed to repo and the data is returned
    - if notification list is empty an exception is thrown NotificationNotFoundExcpetion which is custom created

- GetNotificationByUserIdAndService

    - userid input is validated (only number greater than 0)
    - even if user deleted history can be printed as to maintain the record
    - Call the notification service which implemets the INotificationService
    - Notification List or empty list is returned 
    - filter done based on service type also (email and sms)
    - the service is passed to repo and the data is returned
    - if notification list is empty an exception is thrown NotificationNotFoundExcpetion which is custom created

Delete User

- Usage of delegates for deleting the user to the Dictionary and send notificaiton (both sms and email)

- DeleteUserById

    - id input is validated (only number greater than 0)
    - Call the user service which implemets the IUserService
    - User or null is returned
    - the service is passed to repo and the data is returned
    - if user null an exception is thrown UserNotFoundExcpetion which is custom created
    - if user found with that id is deleted.

- DeleteUserByEmail

    - email is validated (loop untill correct mail is entered)
    - Call the user service which implemets the IUserService
    - User or null is returned by checking if user registered or not
    - the service is passed to repo and the data is returned
    - if user null an exception is thrown UserNotFoundExcpetion which is custom created
    - if user found then registered user with that email is deleted

- DeleteUserByPhone

    - phone number is validated (loop untill correct mail is entered)
    - Call the user service which implemets the IUserService
    - User or null is returned by checking if user registered or not
    - the service is passed to repo and the data is returned
    - if user null an exception is thrown UserNotFoundExcpetion which is custom created
    - if user found then all the resgistered user with that phone number is deleted
    - all user with the registered phone number is deleted.

- Update user

    - Usage of delegates for updating the user to the Dictionary and send notificaiton (both sms and email)
    - check the phone number and email id
    - no duplicate email user can be added
    - check the entered email is not already registered. if found then not possible
    - phone number duplication for a user is allowed
    - a user can have only one email and multiple phone number for registration of user account
    - once inputs are checked user updated to dictionary
    - after updation notification is sent 

All the Needed object such as the service,repo are created in presentation layer and passed in constructor

## Screenshots

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/3ef5e7aa-20ea-4137-8670-e01b25901ca6" />

- Starting of the Application
- Two options one for admin and two for login
- enter the needed options to access the functions

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/1ebf6bb0-9402-4fcc-bdc2-5d21c3f0165d" />

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/6b7236dc-6759-459d-8647-0e3abc0c2765" />

- user added 
- notification sent to the created email and phone number as user created message 

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/2e7cbcbd-72f3-4c4d-8478-d1b91cf2088d" />

- email invalid entry throws exception
- aldready registered email cannot be used to register a new account
- duplication of emil not allowed

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/76d9d6d2-87a4-4233-9229-a1ec4fc1e1aa" />

- another user creation of email kavi@gmail.com and 9489698188 phone number
- notification are sent to email and sms

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/b3dc70c3-c466-4001-abf7-7227bce0fa7d" />

- display all the user

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/0f562508-f64c-44f0-b089-04f53cc7955a" />

- display the user by user Id

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/8d82bc59-c103-40b0-af86-aa7f0260bebc" />

- get user by email
- email not found in the user list so throw a exception

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/1d443343-0f85-41af-b243-50b3d501d283" />

- display the user by email

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/39c1b9ca-a98e-4931-9a0c-6ff487a3fdf9" />

- display the user by phone number (list of user) 
- phone number no needed to be unique only email

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/58c4840a-f57c-4051-a360-3f3aa5d907a7" />

- invalid phone number throw exception
- get user by phone number

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/05c13568-b632-48fa-a9f9-c605942aabf2" />

- display all the notifications

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/5c9cb0a3-473e-465d-83be-0affa6461bfa" />

- updation of user with userId 1 with name
- here also email check that is no repeated email entry is done
- updation send the notification to the user via sms and email

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/927954a7-2128-4efe-9439-0e7c79373fee" />

- deliver message via email
- check email validation if not valid throw email in valid exception
- need to enter message 
- message are validated
- only message sent to registered users

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/b76936c9-ea5d-4c75-a410-001efbf2660f" />

- deliver message to sivakavindratamilselvan@gmail.com
- email sent

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/b43aad84-b317-47cb-a162-07b748d6fa9a" />

- deliver message to phone number
- sms sent

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/21fdd0c2-c841-4892-84e0-bb041aed426a" />

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/72685ca5-0252-4090-a286-f8178be98a6f" />

- get all the notification (creation,updation,deletion,message sent etc)

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/90b90d3c-d6ae-43de-b960-b54548561a15" />

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/be3a48c6-231c-4d89-b5a4-73f81d04e3d0" />

- get all the notification (creation,updation,deletion,message sent etc) for userId 1 
- even if user deleted the notification will be displayed as they are stored in the list as history needed to be maintained

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/4972fb9a-3f1f-419e-86bf-eeaa4ae86a0b" />

- get the notification by notification id

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/87a31962-24de-45c4-a713-e509bff1b221" />

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/409a9257-c0ef-4862-9678-2982319f0e69" />

- user deleted by userId
- sent the notification to sms and email as user deleted

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/07f8b71b-e284-4334-b6da-c7d52b5fbfc3" />

- check userId 1 deleted

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/41a5e3de-d1c5-48b5-8613-66f0626fd5bc" />

- user check in list is done for deletion also (include in updation also)
- if not found throw exception

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/9cb6669c-f05e-49e9-8cd4-57a9b61e4c40" />

- add another user with repeated phone number 9489698188

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/db48727b-de24-49da-b259-94c172115dcb" />

- get all the user to print the existing user

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/3c8d340a-e981-4a48-baae-6602a6774af2" />

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/7344c725-76e4-427c-bc34-0b5cfaeffa9a" />

- delete the user by phone number 9489698188
- in list the user details are collected
- in loop they are deleted
- each user with phone number are deleted
- notification for each user of the phone number is sent

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/452165c8-b4f9-499b-99b7-4a928749477b" />

- check if user are deleted

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/d6675d24-5e0d-43aa-8ad9-b48460a2b797" />

- deliver message via phone number
- as no user found throw exception

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/f8b87074-8ab3-41c6-a4d7-b8db6c0371e6" />

- get notification by notification id

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/bd4c00ff-cb0f-42b5-ab83-10c704516a65" />

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/84dd1238-5a95-491e-bc3c-5a40bd957337" />

- display all the notifications by user id 

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/d783c370-1b09-431b-aa89-e16bba39f585" />

- user login
- display the notification by sms service
- similarly can be applied for the email
