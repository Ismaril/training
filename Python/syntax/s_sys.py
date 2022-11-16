import sys

# todo: checkout more attributes of sys

print(dir(sys))

print(sys.version)
print(sys.version_info)
print(sys.path)
print(sys.int_info)

# standard input out, standard input error (prints out just as normal print())
sys.stdout.write("written into stdout")
sys.stderr.write("written into stderr - error\n")
