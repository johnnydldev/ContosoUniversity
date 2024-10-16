
const imgImput = document.getElementById("imgInp");
const imgUploaded = document.getElementById("imgUploaded");

imgImput.onchange = function event(){
    const [file] = imgImput.files
    if (file) {
        imgUploaded.src = URL.createObjectURL(file)
    }
}

