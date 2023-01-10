namespace La_Mia_Pizzeria_1.Models {
    public class Pizza {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }


        public Pizza() { }

        public Pizza(int id, string title, string description, string image, string price) {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
            Price = price;
        }

    }
}

