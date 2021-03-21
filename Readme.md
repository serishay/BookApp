# Book App using ASP.Net and Angular 

#Backend
 1. Creating Authentication API
	* User should be able to register in the system. 
	* Profile image should be uploaded during registration.
	* A registered user should be able to login to the system
	* Models- User.cs
			  UserContext.cs---------SQL

	* Repository -IAuthenticationRepo.cs
				 AuthenticationRepo.cs

	* BussinessLayer -IAuthenticationService.cs
					 AutenticationService.cs
	
	* Controller -AuthController.cs

 2. Creating Favourite API
	* View all Favorite book cards under Favorite section
	* Models -Favourite.cs
			  FavouriteContext.cs----------MongoDb

	* Repository-IFavouriteRepo.cs
				FavouriteRepo.cs

	* BussinessLayer-IFavouriteService.cs
					FavouriteService.cs

	* Contoller-FavouriteController.cs

 3. Creating Recommendation API
	* View all book recommendations from 3rd party books service provider (openlibrary.org) 
	* Models -Recommendation.cs

	* Repository-IRecommendRepository.cs
				RecommendRepository.cs

	* BussinessLayer-IRecommendService.cs
					RecommendService.cs

	* Contoller-RecommendController.cs

