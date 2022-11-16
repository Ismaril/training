# 'first class' function is a function that allows:
#   - to be passed as an argument
#   - to be returned from a function
#   - to be assigned as a variable

def html_tag(tag):
    def wrap_text(msg):
        print('<{0}>{1}</{0}>'.format(tag, msg))

    return wrap_text


# here function html tag returns function wrap text
print_h1 = html_tag('h1')

# here we assign a value to parameter 'msg'
print_h1('Test Headline!')
print_h1('Another Headline!')

# another example
print_p = html_tag('p')
print_p('Test Paragraph!')
