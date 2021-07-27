let questions = document.getElementsByClassName('question');

for (let i = 0; i < questions.length; i++) {
    const children = Array.from(questions[i].childNodes);
    children.forEach(function (child) {
        if (child.className === 'form-check')
        {
            child.firstElementChild.setAttribute('name', `q${i}`);
        }
    });
}

const btnSubmit = document.querySelector('.btn-user');
let total = 0;

btnSubmit.addEventListener('click', function (e) {
    total = 0;
    for (let i = 0; i < questions.length; i++) {
        const children = Array.from(questions[i].childNodes);
        let point = 0;
        point = Number(children[1].classList[1]);
        for (let j = 0; j < children.length; j++)
        {
            if (children[j].className === 'form-check')
            {
                if (children[j].firstElementChild.classList[1] === 'right' && children[j].firstElementChild.checked)
                {
                    total += point;
                    break;
                }
            }
        }
    }
    document.getElementById('hiddenControl').setAttribute('value', total);
    //e.preventDefault();
});

