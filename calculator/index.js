function appendValue(value) {
    document.getElementById('result').value += value;
  }
  
  function calculate() {
    try {
      const result = eval(document.getElementById('result').value);
      document.getElementById('result').value = result;
    } catch (error) {
      document.getElementById('result').value = 'Error';
    }
  }
  
  function clearResult() {
    document.getElementById('result').value = '';
  }
  document.addEventListener('keydown', function(event) {
    const key = event.key;
    const allowedKeys = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '/', '*', '-', '+', 'Enter','backspace'];
    
    if (allowedKeys.includes(key)) {
      event.preventDefault();
      
      if (key === 'Enter') {
        calculate();
      } else {
        appendValue(key);
      }
    }
  });
  
  
  
  
  
  
  