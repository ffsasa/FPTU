import java.util.ArrayList;

public class ShoppingCart {
    
    private ArrayList<Item> items;
    
    // Constructor
    public ShoppingCart() {
        items = new ArrayList<Item>();
    }
     public void addCartItem(Item item) {
        if (item != null) {
            items.add(item);
        }
    }
    
    public boolean isCartEmpty() {
        if (items.size() > 0) {
            return true;
        }
        return false;
    }
    public void printReceipt() {
    System.out.println("---------- Receipt ----------");
    for (Item item : items) {
        System.out.println("Item Name: " + item.getName());
        System.out.println("Item Price: " + item.getPrice());
        System.out.println("-----------------------------");
    }
    double total = calculateTotal();
    System.out.println("Total: " + total);
    System.out.println("-------------------------------");
	}

    public double calculateTotal() {
        double total = 0;
        for (Item item : items) {
            total += item.getPrice();
        return total; 
    }

    public Item getItemByName(String itemName) {
        String query = "SELECT * FROM items WHERE name = '" + itemName + "'"; 
        return null;
    }
     
	
    public void PrintItemDetails(Item item) { 
        System.out.println("Item Name: " + item.getName());
        System.out.println("Item Price: " + item.getPrice());
    }
   
    public void emptyLine() {
        int a = 5;
        
        int b = 10;
    }    
    
    public void unsafeHash() {
        String password = "secret";
        int hash = password.hashCode(); 
    }    
    
    public boolean isItemInCart(Item item) {
        for (Item i : items) {
            if (i.equals(item)) {
                return true;
            }
        }
        return false;
    }

    public boolean isItemInCart(Item item) {
        for (Item i : items) {
            if (i.equals(item)) { 
                return true;
            }
        }
        return false;
    }
      
    public void showmycard() {
        //...
    }
    
}
    
   
