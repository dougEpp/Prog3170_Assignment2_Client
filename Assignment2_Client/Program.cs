using RestSharp;
using System;

namespace Assignment2_Client
{
    class Program
    {
        const string BASE_ADDRESS = "http://localhost:49899";
        const string APPLICATION_PATH = "/API";
        static void Main(string[] args)
        {
            RestClient restClient = new RestClient(BASE_ADDRESS);
            RestRequest restRequest;

            string resourceName;
            string resourcePath;
            bool exitLoop = false;

            do
            {
                string option;

                Console.Clear();
                Console.WriteLine("Select a resource: ");
                Console.WriteLine("1. Songs");
                Console.WriteLine("2. Reviews");
                Console.WriteLine("3. Exit");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1": // Song CRUD Operations
                        bool exitSongMenu = false;
                        resourceName = "Song";
                        resourcePath = APPLICATION_PATH + "/" + resourceName;
                        do
                        {
                            string songOption;

                            Console.Clear();
                            Console.WriteLine("Select an action: ");
                            Console.WriteLine("1. Get all songs");
                            Console.WriteLine("2. Get a specific song");
                            Console.WriteLine("3. Add a new song");
                            Console.WriteLine("4. Update a song");
                            Console.WriteLine("5. Delete a song");
                            Console.WriteLine("6. Exit to main menu");
                            songOption = Console.ReadLine();

                            switch (songOption)
                            {
                                case "1": // Get all songs
                                    restRequest = new RestRequest(resourcePath, Method.GET);
                                    GetAllSongs(restClient,restRequest);

                                    Console.ReadKey();
                                    break;
                                case "2": // Get specific song
                                    string requestedSongId;
                                    string requestedSongResourcePath;
                                    Console.Write("Song id: ");
                                    requestedSongId = Console.ReadLine();
                                    requestedSongResourcePath = resourcePath + "/" + requestedSongId;

                                    restRequest = new RestRequest(requestedSongResourcePath, Method.GET);
                                    GetSelectedSong(restClient, restRequest);

                                    Console.ReadKey();
                                    break;
                                case "3": // Add song
                                    restRequest = new RestRequest(resourcePath, Method.POST);
                                    AddSong(restClient, restRequest);
                                    break;
                                case "4": // Update song

                                    string updatedSongId;
                                    string updatedSongResourcePath;
                                    Console.Write("Song id: ");
                                    updatedSongId = Console.ReadLine();
                                    updatedSongResourcePath = resourcePath + "/" + updatedSongId;

                                    // Get details of the song to be updated
                                    restRequest = new RestRequest(updatedSongResourcePath, Method.GET);
                                    GetSelectedSong(restClient, restRequest);

                                    // Now update the selected song
                                    restRequest = new RestRequest(updatedSongResourcePath, Method.PUT);
                                    UpdateSong(updatedSongId, restClient, restRequest);
                                    Console.ReadKey();
                                    break;
                                case "5": // Delete Song
                                    string deletedSongId;
                                    string deletedSongResourcePath;
                                    Console.Write("Song id: ");
                                    deletedSongId = Console.ReadLine();
                                    deletedSongResourcePath = resourcePath + "/" + deletedSongId;

                                    // Get details of the song to be deleted
                                    restRequest = new RestRequest(deletedSongResourcePath, Method.GET);
                                    GetSelectedSong(restClient, restRequest);

                                    restRequest = new RestRequest(deletedSongResourcePath, Method.DELETE);
                                    DeleteSong(restClient, restRequest);
                                    Console.ReadKey();
                                    break;
                                case "6":
                                    exitSongMenu = true;
                                    break;
                                default:
                                    break;
                            }
                        } while (!exitSongMenu);
                        break;
                    case "2": // Review CRUD Operations
                        bool exitReviewMenu = false;
                        do
                        {
                            string reviewOption;
                            resourceName = "Review";
                            resourcePath = APPLICATION_PATH + "/" + resourceName;

                            Console.Clear();
                            Console.WriteLine("Select an action: ");
                            Console.WriteLine("1. Get all reviews");
                            Console.WriteLine("2. Get a specific review");
                            Console.WriteLine("3. Add a new review");
                            Console.WriteLine("4. Update a review");
                            Console.WriteLine("5. Delete a review");
                            Console.WriteLine("6. Exit to main menu");
                            reviewOption = Console.ReadLine();

                            switch (reviewOption)
                            {
                                case "1": // Get all reviews
                                    restRequest = new RestRequest(resourcePath, Method.GET);
                                    GetAllReviews(restClient, restRequest);

                                    Console.ReadKey();
                                    break;
                                case "2": // Get specific review
                                    string requestedReviewId;
                                    string requestedReviewResourcePath;
                                    Console.Write("Review id: ");
                                    requestedReviewId = Console.ReadLine();
                                    requestedReviewResourcePath = resourcePath + "/" + requestedReviewId;

                                    restRequest = new RestRequest(requestedReviewResourcePath, Method.GET);
                                    GetSelectedReview(restClient, restRequest);

                                    Console.ReadKey();
                                    break;
                                case "3": // Add review
                                    restRequest = new RestRequest(resourcePath, Method.POST);
                                    AddReview(restClient, restRequest);
                                    break;
                                case "4": // Update review

                                    string updatedReviewId;
                                    string updatedReviewResourcePath;
                                    Console.Write("Review id: ");
                                    updatedReviewId = Console.ReadLine();
                                    updatedReviewResourcePath = resourcePath + "/" + updatedReviewId;

                                    // Get details of the review to be updated
                                    restRequest = new RestRequest(updatedReviewResourcePath, Method.GET);
                                    GetSelectedReview(restClient, restRequest);

                                    // Now update the selected review
                                    restRequest = new RestRequest(updatedReviewResourcePath, Method.PUT);
                                    UpdateReview(updatedReviewId, restClient, restRequest);
                                    Console.ReadKey();
                                    break;
                                case "5": // Delete Review
                                    string deletedReviewId;
                                    string deletedReviewResourcePath;
                                    Console.Write("Review id: ");
                                    deletedReviewId = Console.ReadLine();
                                    deletedReviewResourcePath = resourcePath + "/" + deletedReviewId;

                                    // Get details of the review to be deleted
                                    restRequest = new RestRequest(deletedReviewResourcePath, Method.GET);
                                    GetSelectedReview(restClient, restRequest);

                                    restRequest = new RestRequest(deletedReviewResourcePath, Method.DELETE);
                                    DeleteReview(restClient, restRequest);
                                    Console.ReadKey();
                                    break;
                                case "6":
                                    exitReviewMenu = true;
                                    break;
                                default:
                                    break;
                            }
                        } while (!exitReviewMenu);
                        break;
                    case "3":
                        exitLoop = true;
                        break;
                    default:
                        break;
                }
            } while (!exitLoop);
        }
        public static void GetAllSongs(RestClient restClient, RestRequest restRequest)
        {
            Console.Clear();
            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine(restResponse.Content);
        }
        public static void GetSelectedSong(RestClient restClient, RestRequest restRequest)
        {
            Console.Clear();
            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine(restResponse.Content);
        }
        public static void AddSong(RestClient restClient, RestRequest restRequest)
        {
            Console.Clear();
            string newTitle;
            string newAlbumName;
            string newArtist;
            string newGenre;
            string option;
            Console.Write("New Song Title: ");
            newTitle = Console.ReadLine();
            Console.Write("New Song Album: ");
            newAlbumName = Console.ReadLine();
            Console.Write("New Song Artist: ");
            newArtist = Console.ReadLine();
            Console.Write("New Song Genre: ");
            newGenre = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("New Song Title: " + newTitle);
            Console.WriteLine("New Song Album: " + newAlbumName);
            Console.WriteLine("New Song Artist: " + newArtist);
            Console.WriteLine("New Song Genre: " + newGenre);

            Console.WriteLine("Ready to add? Y=Yes, N=No, C=Cancel");
            option = Console.ReadLine();
            switch (option)
            {
                case "Y":
                case "y":
                    restRequest.AddParameter("title", newTitle);
                    restRequest.AddParameter("albumName", newAlbumName);
                    restRequest.AddParameter("artist", newArtist);
                    restRequest.AddParameter("genre", newGenre);
                    IRestResponse restResponse = restClient.Execute(restRequest);
                    Console.WriteLine(restResponse.Content);
                    Console.ReadLine();
                    break;
                case "N":
                case "n":
                    AddSong(restClient, restRequest);
                    break;
                default:
                    break;
            }
        }
        public static void UpdateSong(string resourceId, RestClient restClient, RestRequest restRequest)
        {
            string newTitle;
            string newAlbumName;
            string newArtist;
            string newGenre;
            Console.Write("New Song Title: ");
            newTitle = Console.ReadLine();
            Console.Write("New Song Album: ");
            newAlbumName = Console.ReadLine();
            Console.Write("New Song Artist: ");
            newArtist = Console.ReadLine();
            Console.Write("New Song Genre: ");
            newGenre = Console.ReadLine();

            restRequest.AddParameter("songID", resourceId);
            restRequest.AddParameter("title", newTitle);
            restRequest.AddParameter("albumName", newAlbumName);
            restRequest.AddParameter("artist", newArtist);
            restRequest.AddParameter("genre", newGenre);

            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine(restResponse.Content);
        }
        public static void DeleteSong(RestClient restClient, RestRequest restRequest)
        {
            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine(restResponse.Content);
        }
        public static void GetAllReviews(RestClient restClient, RestRequest restRequest)
        {
            Console.Clear();
            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine(restResponse.Content);
        }
        public static void GetSelectedReview(RestClient restClient, RestRequest restRequest)
        {
            Console.Clear();
            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine(restResponse.Content);
        }
        public static void AddReview(RestClient restClient, RestRequest restRequest)
        {
            Console.Clear();
            string newMessage;
            string newRating;
            string newSongId;
            string option;
            Console.Write("Song Id: ");
            newSongId = Console.ReadLine();
            Console.Write("New Review text: ");
            newMessage = Console.ReadLine();
            Console.Write("New Song Rating: ");
            newRating = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Song Id: " + newSongId);
            Console.WriteLine("Review Text: " + newMessage);
            Console.WriteLine("Rating: " + newRating);

            Console.WriteLine("Ready to add? Y=Yes, N=No, C=Cancel");
            option = Console.ReadLine();
            switch (option)
            {
                case "Y":
                case "y":
                    restRequest.AddParameter("message", newMessage);
                    restRequest.AddParameter("rating", newRating);
                    restRequest.AddParameter("songId", newSongId);
                    IRestResponse restResponse = restClient.Execute(restRequest);
                    Console.WriteLine(restResponse.Content);
                    Console.ReadLine();
                    break;
                case "N":
                case "n":
                    AddReview(restClient, restRequest);
                    break;
                default:
                    break;
            }
        }
        public static void UpdateReview(string resourceId, RestClient restClient, RestRequest restRequest)
        {
            string newMessage;
            string newRating;
            string newSongId;
            Console.Write("Song Id: ");
            newSongId = Console.ReadLine();
            Console.Write("New Review text: ");
            newMessage = Console.ReadLine();
            Console.Write("New Song Rating: ");
            newRating = Console.ReadLine();

            restRequest.AddParameter("reviewID", resourceId);
            restRequest.AddParameter("message", newMessage);
            restRequest.AddParameter("rating", newRating);
            restRequest.AddParameter("songId", newSongId);

            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine(restResponse.Content);
        }
        public static void DeleteReview(RestClient restClient, RestRequest restRequest)
        {
            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine(restResponse.Content);
        }
    }
}
