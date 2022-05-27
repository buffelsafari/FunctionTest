// See https://aka.ms/new-console-template for more information
using FunctionTest;

Console.WriteLine("Hello, World!");


BaseNode a = new ConstantNode(3);
BaseNode b = new ConstantNode(5);

BaseNode c = a * b/(a*b)+b-a;

Console.WriteLine("nodeValue=" + c.GetValue());

Matrix m = new Matrix(4);

m.SetValue(0, 0, new ConstantNode(1));
m.SetValue(0, 1, new ConstantNode(1));
m.SetValue(0, 2, new ConstantNode(1));
m.SetValue(0, 3, new ConstantNode(-1));

m.SetValue(1, 0, new ConstantNode(1));
m.SetValue(1, 1, new ConstantNode(1));
m.SetValue(1, 2, new ConstantNode(-1));
m.SetValue(1, 3, new ConstantNode(1));

m.SetValue(2, 0, new ConstantNode(1));
m.SetValue(2, 1, new ConstantNode(-1));
m.SetValue(2, 2, new ConstantNode(1));
m.SetValue(2, 3, new ConstantNode(1));

m.SetValue(3, 0, new ConstantNode(-1));
m.SetValue(3, 1, new ConstantNode(1));
m.SetValue(3, 2, new ConstantNode(1));
m.SetValue(3, 3, new ConstantNode(1));

m.Print();
BaseNode d=Matrix.Det(m);

Console.WriteLine("det="+d.GetValue());

Console.WriteLine("cofactor---");

Matrix adjMat = Matrix.GetAdjugateMatrix(m);
adjMat.Print();


Matrix invMat=Matrix.Inverse(m);
invMat.Print();


Vector vec = new Vector(4);
vec.SetValue(0, new ConstantNode(1));
vec.SetValue(1, new ConstantNode(2));
vec.SetValue(2, new ConstantNode(3));
vec.SetValue(3, new ConstantNode(4));
Vector res=m.Mult(vec);

m.Print();
Console.WriteLine("-------------");
vec.Print();
res.Print();

