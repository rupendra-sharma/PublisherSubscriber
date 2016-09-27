# PublisherSubscriber
Code base implements the publisher -subscriber design pattern using WCF service with wsDualHttpBinding

# How to use:
1. Deploy the service to IIS at http://localhost/publisher/ and test the access of http://localhost/publisher/service.svc
2. Rebuild the project in Debug / Release mode
3. Go to ~/PublisherSubscriber\Subscriber\bin\Debug and run Subscriber.exe with Administrator rights
4. Run the MVC4 application Information source on browser
5. Fill the message parts and hit send
6. Check if the message was published on the Subscriber console
7. This application publish messages to n number of Subscriber consoles

# Future enhancements
1. Implement Unity IoC container to for the dependency injection across all the applications
2. Create Unit test cases for Service, Information Source and Subscriber
3. Use mocking framework to test the WCF service
4. Load testing 
5. Preserve the messages and setup a message queue to deliver the message later on just in case any client is down
