**## Problem 1 : Fixed array size**



**Why it's a problem ?**

&#x20; \* because these limits are technical constrains caused by using fixed size array , not real business rules.

&#x20;  when a limit is reached , the program only prints an error and refuse to add more data

**What can go wrong:** A real shop can pass these limits quickly, and the program will then refuse to add new customers, products, or orders.



**## problem 2 :** Global Variables



**Why it's a problem ?**

&#x20;  \* All arrays and counters are global variables. Any function can read or

&#x20;change them and No part of the code protects the data.

**What can go wrong:** A small mistake in one function can break the data for the whole program.

&#x20;It is also hard to test, because I cannot start with a clean, empty state.







**## problem 3 :** Parallel Array

A customer is stored in five arrays: customerIds, customerNames, customerEmails, customerCities and customerIsVip.The same problem exists for products and orders.

**Why it's a problem?**

&#x20;   \* This means one customer is not represented as a single object. Only the same index number connects them and Adding a new field means a new array and changes in many places.

**What can go wrong:**

\* If I add a new field, I must change many places, and if I forget one, the data gets mixed up.

&#x20;If a customer is deleted from some arrays but not others, a name can end up with the wrong email.





**## problem 4 :** Input Validation Is Very Weak ...The program checks very little of what goes in.

**Why it's a problem?**

&#x20;\* Wrong data is accepted and then stored as if it were correct. Only a few checks exist, such as quantity above zero and duplicate ids.



**What can go wrong:**

&#x20;  \* If the user enters a letter instead of a number, cin can fail and cause problems with the next inputs.

A negative price can also make the order total wrong.

A wrong date can cause problems when searching or sorting data.



\## problem 5 : Money stored in Double



**Why it's a problem?**

&#x20; \* double can have small rounding errors when working with decimal numbers.



**What can go wrong?**

&#x20; The total price may not always have the exact value we expect.

In C#, decimal is a better choice for money because it gives better decimal precision.



**##Problem 6:** No Encapsulation....The program does not use classes to protect its data.



**why it's a problem?**

&#x20;\* The program does not use classes to protect its data and There are no clear rules for how the data should be changed.



**What can go wrong:**

&#x20; A function can put invalid data into the program.

Using classes and encapsulation can make the data safer and easier to control.





**## problem 7:** 



