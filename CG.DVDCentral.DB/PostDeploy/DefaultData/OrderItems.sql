begin 
	Insert into tblOrderItem (Id, OrderId, Quantity, MovieId, Cost)
	values 
	(1, 1, 2, 1, 39.98),  -- 2 copies of "The Great Escape" for Order 1
    (2, 2, 1, 2, 24.99),  -- 1 copy of "Pulp Fiction" for Order 2
    (3, 3, 3, 3, 89.97)  -- 3 copies of "The Dark Knight" for Order 3
end 