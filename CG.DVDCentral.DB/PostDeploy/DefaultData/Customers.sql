begin 
	Insert into tblCustomer (Id, FirstName, LastName, UserId, Address, City, State, ZIP, Phone, ImagePath)
	values 
	(1, 'Alice', 'Johnson', 1, '123 Main St', 'Springfield', 'WI', '62704', '555-1234', '/images/alice.jpg'),
    (2, 'Bob', 'Williams', 2, '456 Oak St', 'Shelbyville', 'CA', '62705', '555-5678', '/images/bob.jpg'),
    (3, 'Cathy', 'Brown', 3, '789 Pine St', 'Capital City', 'KY', '62706', '555-9101', '/images/cathy.jpg')
end 