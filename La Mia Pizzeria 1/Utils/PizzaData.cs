using La_Mia_Pizzeria_1.Models;
using Microsoft.Extensions.Hosting;

namespace La_Mia_Pizzeria_1.Utils {
    public static class PizzaData {
        private static List<Pizza> pizzas;

        public static List<Pizza> GetPizzas() {
            string[] PizzasTitle = { "Margherita", "Peperoni", "Vegetariana" };
            
            string[] PizzaDesc = { "Una pizza classica con salsa di pomodoro, mozzarella e basilico fresco."
            ,"Una pizza salata con salsa di pomodoro, mozzarella e peperoni piccanti.","Una gustosa pizza con salsa di pomodoro, mozzarella e una varietà di verdure."};
            
            string[] PizzaImage = { "https://primochef.it/wp-content/uploads/2019/08/SH_pizza_fatta_in_casa-1200x800.jpg", "https://www.ristorantelespecialita.it/wp-content/uploads/2016/04/Pizza-con-peperoni.jpg"
            ,"https://i0.wp.com/farinespeciali.it/wp-content/uploads/2021/09/pizza-con-avocado-olive-cipolla.jpg?fit=1200%2C800&ssl=1"};
            
            string[] PizzaPrice = { "$10", "$12", "$11" };


            if (pizzas != null) {
                return pizzas;
            }

            pizzas = new List<Pizza>();
            for (int i = 0; i < PizzasTitle.Length; i++) {
                Pizza PizzaGenerato = new Pizza(i, PizzasTitle[i], PizzaDesc[i], PizzaImage[i], PizzaPrice[i]);
                pizzas.Add(PizzaGenerato);

            }
            return pizzas;

        }
    }
}
