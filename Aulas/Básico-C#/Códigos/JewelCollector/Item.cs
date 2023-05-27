namespace JewelCollector;

public class Item {
    public int xPosition;
    public int yPosition;
    public string symbol;
    public bool transpassable;
    public bool collectable;

    //Constructor:
    public Item (int xPosition, int yPosition, string symbol, bool transpassable, bool collectable){
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        this.symbol = symbol;
        this.transpassable = transpassable;
        this.collectable = collectable;
    }

    //toString():
    public string toString(){
        return symbol;
    }

    //gets e sets:
    public int getXPosition() {
        return this.xPosition;
    }

    public void setXPosition(int xPosition){
        this.xPosition = xPosition;
    }

    public int getYPosition() {
        return this.yPosition;
    }

    public void setYPosition(int yPosition){
        this.yPosition = yPosition;
    }
    public string getSymbol(){
        return this.symbol;
    }

    public void setSymbol(string symbol){
        this.symbol = symbol;
    }

    public bool getTranspassable(){
        return this.transpassable;
    }

    public void setTranspassable(bool transpassable){
        this.transpassable = transpassable;
    }

    public bool getCollectable(){
        return this.collectable;
    }

    public void setCollectable(bool collectable){
        this.collectable = collectable;
    }
}
