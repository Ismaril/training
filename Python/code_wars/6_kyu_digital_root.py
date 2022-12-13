# example
# 761 = 7+6+1 = 14 = 5

def digital_root(n):
    result = sum([int(num) for num in str(n)])
    if len(str(result)) == 1:
        return result
    else:
        return digital_root(result)

print(digital_root(761))
