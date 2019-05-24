class Figure
{
protected:
   Figure() {}
 
public:
   virtual ~Figure() {}
 
   // Aufbau:
   // virtual Rückgabetyp nameDerFunktion(Variable1, Variable2, VariableN) = 0;
   // mit dem "= 0" zwingt man den Programmierer die Methode zu implementieren!!!
   // Sonst gibt es Fehler beim Kompilieren...
   virtual double getX() = 0;
   virtual double getY() = 0;
 
   virtual void setX(double x) = 0;
   virtual void setY(double y) = 0;
 
   virtual short scaleUp(int factor) = 0;
   virtual short scaleDown(int factor) = 0;
};
