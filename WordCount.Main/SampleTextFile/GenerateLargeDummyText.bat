echo "This is just a sample line appended to create a big file.. " > dummy.txt
for /L %%i in (1,1,1) do type dummy.txt >> dummy.txt