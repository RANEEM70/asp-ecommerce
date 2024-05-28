

namespace CodeCrafters_backend_teamwork.src.DTOs
{
    public class OrderCheckoutReadDto
    {
         public Guid Id {get ; set;}
        public required string Payment {get ; set;}
        public Guid UserId {get ; set;}
        public required string Shipping {get ; set;}
        public required string Status {get ; set;}
        public double TotalPrice {get ; set;}
    }


     public class OrderCheckoutCreateDto
     {
    
        public string Payment {get ; set;}
        public Guid UsersId {get ; set;}
        public string Shipping {get ; set;}
        public required string Status {get ; set;}
        public double TotalPrice {get ; set;}
    }
    
     public class OrderCheckoutUpdateDto
     {
        public Guid Id {get ; set;}
        public required string Payment {get ; set;}
        public int UsersId {get ; set;}
        public required string Shipping {get ; set;}
        public required string Status {get ; set;}
        public double TotalPrice {get ; set;}
    }


}