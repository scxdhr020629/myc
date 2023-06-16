void main(int n) { 
  int i; 
  i=0; 
  while (i < 3) { 
    if (i == 1) {
        break;
        i = i + 1;
        continue;
    }
    print i; 
    

    i=i+1;
  } 
}