class Coach extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: props.coach };
        this.onClick = this.onClick.bind(this);
        this.link = "/Coach/Edit/" + this.state.data.Id;
        this.flag = false;
    }
    onClick(e) {

        this.props.onRemove(this.state.data);
    }
    coachList() {
        return <tr>
                <td>{this.state.data.Name}</td>
                <td>{this.state.data.LastName}</td>
                <td>{this.state.data.Age}</td>
            <td>
                <a href={this.link} style={{ color: "cadetblue", textDecoration: "none" }}>Edit </a>

                <button style={{ color: "red" }} onClick={this.onClick} id="delete">Delete</button>
                </td>
        </tr>;
    }
    render() {
        return this.coachList(); 
    }
}

class CoachForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = { name: "", lastName: "", age: 0};
        

        this.onSubmit = this.onSubmit.bind(this);
        this.onChangeName = this.onChangeName.bind(this);
        this.onChangeLastName = this.onChangeLastName.bind(this);
        this.onChangeAge = this.onChangeAge.bind(this);
    }
    
    onChangeName(e) {

        this.setState({ name: e.target.value});
    }
    onChangeLastName(e) {
        this.setState({ lastName: e.target.value });
    }
    onChangeAge(e) {

        this.setState({ age: e.target.value });
    }
    onSubmit(e) {
        e.preventDefault();
        var coachName = this.state.name.trim();
        var coachLastName = this.state.lastName.trim();
        var coachAge = this.state.age.trim();
       
        if (!coachName) {
            return;
        }
        if (!coachLastName) {
            return
        }
        if (!coachAge) {
            return
        }
        this.props.onCoachSubmit({ name: coachName, lastName: coachLastName, age: coachAge });
        console.log(this.props.onCoachSubmit);
        this.setState({ name: "", lastName: "", age: 0 });
    }
    render() {
        return (
            <form onSubmit={this.onSubmit}>
                <p>
                    <input type="text"
                        placeholder="Name"
                        value={this.state.name}
                        onChange={this.onChangeName}
                        id="name"/>
                   
                </p>
                <p>
                    <input type="text"
                        placeholder="Last name"
                        value={this.state.lastName}
                        onChange={this.onChangeLastName}
                        id="lastName"
                    />
                </p>
                <p>
                    <input type="number"

                        value={this.state.age}
                        onChange={this.onChangeAge}
                        id="age"
                    />
                </p>
                <input type="submit" style={{ color: "green" }} value="Add a coach" id="addCoach"/>
            </form>
        );
    }
}

class CoachesList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { coaches: [] };
        this.onRemoveCoach = this.onRemoveCoach.bind(this);
        this.onAddCoach = this.onAddCoach.bind(this);
    }

    loadData() {
  
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.getUrl, true);

        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
       
            this.setState({ coaches: data });
        }.bind(this);
        
        xhr.send();
    }
    componentDidMount() {
        this.loadData();
    }

    onAddCoach(coach) {

        if (coach) {
            console.log(coach);
            var data = new FormData();
            data.append("name", coach.name);
            data.append("lastName", coach.lastName);
            data.append("age", coach.age);
           
            var xhr = new XMLHttpRequest();
            xhr.open("post", this.props.postUrl, true);

            xhr.onload = function () {
                if (xhr.status == 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send(data);
        }
    }
    
    onRemoveCoach(coach) {

        if (coach) {
            var data = new FormData();
            data.append("id", coach.Id);
            var xhr = new XMLHttpRequest();
            xhr.open("delete", this.props.deleteUrl, true);
            xhr.onload = function () {
                if (xhr.status == 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send(data);
        }
    }
   
    render() {

        var remove = this.onRemoveCoach;
       
        return <div>
            <CoachForm onCoachSubmit={this.onAddCoach} />
            <h2>List coaches</h2>
            <div>
                <table className="table" >
                    <thead>
                        <tr>
                            <th><b>Name</b></th>
                            <th><b>Last name</b></th>
                            <th><b>Age</b></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                    {
                        this.state.coaches.map(function (coach) {
                            return <Coach key={coach.Id} coach={coach} onRemove={remove}/>
                        })
                    }
                    </tbody>
                </table>
            </div>
        </div>;
    }
}

ReactDOM.render(
    <CoachesList getUrl="/Coach/GetCoaches" deleteUrl="/Coach/Delete" postUrl="/Coach/Create" />,
    document.getElementById("content")
);