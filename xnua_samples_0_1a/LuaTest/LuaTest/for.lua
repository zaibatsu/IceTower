--
--
a=0
for i=2,3 do
  local x = i * 2
  a = a + x
end

print(a)
tab={foo=5,1,3,5 }
print("tab contents")
print(tab.foo)
print(tab[1])
print(tab[2])
print(tab[3])
print("end")
print( "------tab" )
for x,y in tab do
  print(x,"   ",y)
end
print( "--------pairs" )
for x,y in pairs(tab) do
	print(x,"  ",y)
end

table.insert(tab, 10)
table.insert(tab, 11)
print( "--------ipairs" )
for x,y in ipairs(tab) do
	print(x,"  ",y)
end

table.remove(tab,4)
print( "--------pairs" )
for x,y in pairs(tab) do
	print(x,"  ",y)
end
print("end")
