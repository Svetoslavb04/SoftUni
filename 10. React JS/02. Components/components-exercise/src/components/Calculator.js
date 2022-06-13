import { Button } from "./Button";
import { TextBox } from "./TextBox";
import React from 'react';

export const Calculator = (props) => {
    const [calc, setCalc] = React.useState({});

    const numbers = [];
    
    for (let i = 1; i <= props.totalNumbers; i++) {
        numbers.push(`number${i}`);
    }

    const sumHandler = () => {
        const sum = Object.values(calc.numbers).reduce((prev, curr) => Number(prev) + Number(curr), 0);

        setCalc(prev => { return { numbers: prev.numbers, sum } })
    }

    React.useEffect(() => {
        const numbersObj = {};

        for (let i = 1; i <= props.totalNumbers; i++) {
            numbersObj[`number${i}`] = 0;
        }

        setCalc({ numbers: { ...numbersObj }, sum: 0 })
    }, [])

    return (
        <div>
            {numbers.map((num, i) => {
                return <TextBox
                    name={num}
                    onChange={(e) => {
                        setCalc(prevCalc => {
                            const calcState = { ...prevCalc };
                            calcState['numbers'][`number${num}`] = e.target.value;

                            return calcState;
                        })
                    }}
                    key={i}
                >{num}</TextBox>
            })}
            <TextBox name="sum" disabled>{calc.sum}</TextBox>
            <Button onClick={sumHandler}>Sum</Button>
        </div>
    );
}