## Service Fabric Actors integration with modern DI

This project is meant to be a Proof of Concept about the possibility to implement Actors while 
still using the Microsoft Dependency Injection framework, and the Generic Host.

The only Actor in the solution is created through a Hosted Service that triggers the `ActorService`
creation, by which the Actor will be eventually created.

Another simple hosted service is defined in the application with the sole purpose of pinging the
Actor instance through an `ActorProxy` instance, to prove that the Actor is working.

### Limitation

This approach is only partially viable, because it is not possible to inject dependency into the
Actor instance only with the DI. The dependencies will have to either be:

- Injected directly as a method parameter, rather than in the constructor.
- Injected inside the `ActorService` instance, and then relayed to the actor through a factory in the
  `ActorService`.
