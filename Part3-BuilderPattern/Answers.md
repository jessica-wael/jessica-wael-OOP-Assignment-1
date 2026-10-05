##### **Answers:**





***Q1.*** Why is a single 20-parameter constructor for this class a problem in practice?



* Unreadable :It is hard to understand what each argument represents when creating an object
* Parameter order mistakes: Two parameters may have the same type such as SubTotal and DiscountAmount, or BillingStreet and ShippingStreet. Accidentally swapping them may not cause a compiler error, but it can produce incorrect data..
* Harder testing and debugging: A long list of arguments makes it more difficult to identify missing or incorrect values.





***Q2.*** Is it only a "constructor is too long" problem?



No. The problem is not only the long constructor. The class contains different types of information,

&#x20;and billing and shipping addresses have similar properties.

&#x20;We can make the design better by grouping related properties into smaller classes such as "Address" and "Order".



