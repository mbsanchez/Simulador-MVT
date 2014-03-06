* Preludio estandar
0:          LD    6, 0(0)
1:          ST    0, 0(0)
2:          LDA   7, 7(7)
* Función Read
3:          LD    1, 0(1)
4:          IN    0, 0, 0 Leer un entero desde la entrada
5:          ST    0, 0(1)
6:          LDA   7, 0(4)
* Función Write
7:          LD    0, 0(1)
8:          OUT   0, 0, 0
9:          LDA   7, 0(4)
* Cargar las direcciones de las funciones básicas
10:         LDC   0, 3(0)
11:         ST    0, 0(5)
12:         LDC   0, 7(0)
13:         ST    0, 3(5)
* Instrucciones del programa
14:         LDA   0, 1(5)
15:         ST    0, 0(6)
16:         LDA   1, 0(6)
17:         LDA   4, 1(7)
18:         LD    7, 0(5)
19:         LDC   0, 0(0)
20:         ST    0, 0(6)
21:         LD    0, 1(5)
22:         LD    1, 0(6)
23:         SUB   0, 1, 0
24:         JLT   0, 2(7)
25:         LDC   0, 0(0)
26:         LDA   7, 1(7)
27:         LDC   0, 1(0)
28:         JEQ   0, 29(7)
29:         LDC   0, 1(0)
30:         ST    0, 2(5)
31:         LD    0, 2(5)
32:         ST    0, 0(6)
33:         LD    0, 1(5)
34:         LD    1, 0(6)
35:         MUL   0, 1, 0
36:         ST    0, 2(5)
37:         LD    0, 1(5)
38:         ST    0, 0(6)
39:         LDC   0, 1(0)
40:         LD    1, 0(6)
41:         SUB   0, 1, 0
42:         ST    0, 1(5)
43:         LD    0, 1(5)
44:         ST    0, 0(6)
45:         LDC   0, 0(0)
46:         LD    1, 0(6)
47:         SUB   0, 1, 0
48:         JEQ   0, 2(7)
49:         LDC   0, 0(0)
50:         LDA   7, 1(7)
51:         LDC   0, 1(0)
52:         JEQ   0, -22(7)
53:         LD    0, 2(5)
54:         ST    0, 0(6)
55:         LDA   1, 0(6)
56:         LDA   4, 1(7)
57:         LD    7, 3(5)
58:         HALT  0, 0, 0