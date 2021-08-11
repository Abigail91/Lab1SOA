import React from "react";

export class StarWarsCharacters extends React.Component {
    constructor(props) {
    super(props);
    this.state = {value: '',value2:''};

    this.handleChange = this.handleChange.bind(this);
    this.handleChange2 = this.handleChange2.bind(this);

    this.reservaEspacio = this.reservaEspacio.bind(this);
    this.desocuparEspacio = this.desocuparEspacio.bind(this);
  }
   handleChange(event) {
    this.setState({value: event.target.value});
  }
  handleChange2(event) {
    this.setState({value2: event.target.value});
  }
    async reservaEspacio(event){
        
    event.preventDefault();
        const response = await fetch('http://localhost:5000/api/reservations',{
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            placa:this.state.value
        })
    });
        const data = await response.json();
        console.log(data);
        alert('Se reservo el espacio: ' + data.id);
    }
    async desocuparEspacio(event){
        
    event.preventDefault();
        const response = await fetch('http://localhost:5000/api/spaces/' ,{
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id:this.state.value2,
            placa: null,
            state: "free"
        })
    });
        const data = await response.json();
        console.log(data);
        alert('Se libero el espacio');
    }
    
    render() {
        if (!this.props.characters) {
            return <></>;
        }
        return (
        <div>
        <form>
        <input value={this.state.value}  onChange={this.handleChange} placeholder="Digite el numero de placa" />
        <button onClick={this.reservaEspacio}>
            Reservar espacio
        </button>
        <input value={this.state.value2}  onChange={this.handleChange2} placeholder="Digite el numero de espacio" />
        <button onClick={this.desocuparEspacio}>
            Desocupar espacio
        </button>
        </form>
        <table>
            {this.props.characters.map(e =>
                <tr>
                    <td>{e.id}</td>
                    <td>{e.state}</td>
                </tr>)
            }
        </table>
        </div>);
    }
}