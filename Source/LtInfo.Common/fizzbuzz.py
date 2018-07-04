import sys
# fizz buzz

keys = [3, 5, 7, 11]
data = {
    3: "Fizz",
    5: "Buzz",
    7: "Pop",
    11: "Tart"
}

def fizzbuzz(i, ks, d):
    '''
    :param i: integer for which to generate string
    :param ks: list of ints
    :param d: dict of (int, string)

    :return: string
    '''

    # mult three: print "fizz"
    # mult five : print "buzz"
    # mult five & three : print "fizzbuzz"
    # none: print number

    # mult seven: print "Pop"
    # mult eleven: print "Tart"

    st = ''
    for k in ks:
        if i % k == 0:
            st += d[k]

    if len(st) == 0:
        return str(i)
    else:
        return st
    '''
    if i % 3 == 0 and i % 5 == 0:
        print "FizzBuzz"
    elif i % 3 == 0:
        print "Fizz"
    elif i % 5 == 0:
        print "Buzz"
    else:
        print i
    '''
def test():

    assert(fizzbuzz(3, keys, data) == "Fizz")
    assert(fizzbuzz(2, keys, data) == "2")
    assert(fizzbuzz(5, keys, data) == "Buzz")
    assert(fizzbuzz(15, keys, data) == "FizzBuzz")
    assert(fizzbuzz(7, keys, data) == "Pop")
    assert(fizzbuzz(11, keys, data) == "Tart")
    assert(fizzbuzz(77, keys, data) == "PopTart")
    assert(fizzbuzz(3*5*7*11, keys, data) == "FizzBuzzPopTart")
    # assert(fizzbuzz(2, keys, data) == "Fizz")  # should fail


test()
for i in range(1,101):
    print fizzbuzz(i, keys, data)