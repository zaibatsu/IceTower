-- $Id: sieve.lua,v 1.9 2001/05/06 04:37:45 doug Exp $
-- http://www.bagley.org/~doug/shootout/
-- contributed by Roberto Ierusalimschy
--
-- Roberto Ierusalimschy pointed out the for loop is much
-- faster for our purposes here than using a while loop.

local count = 0

local function main(num)
    local flags = {}
    for num=1,num do
      count = 0
      for i=2,8192 do
        flags[i] = true
      end
      for i=2,8192 do
        if flags[i] then
          for k=i+i, 8192, i do
            flags[k] = false
          end
          count = count + 1    
        end
      end
    end
end

--NUM = tonumber((arg and arg[1])) or 1
local NUM=10

t1=os.clock()
main(NUM)
t2=os.clock()
--io.write("Count: ", count, "\n")
print(t2-t1)
