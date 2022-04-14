import { ChangeEvent, FormEvent, useState } from "react";
import { Button, Form } from "react-bootstrap";
import { Activity } from "../../../app/models/activity";

interface Props {
  activity: Activity | undefined;
  closeForm: () => void;
  createOrEdit: (activity: Activity) => void;
}

export default function ActivityForm({
  activity: selectedActivity,
  closeForm,
  createOrEdit,
}: Props) {
  const initialState = selectedActivity ?? {
    id: "",
    title: "",
    description: "",
    category: "",
    date: "",
    city: "",
    venue: "",
  };

  const [activity, setActivity] = useState(initialState);

  function handleSubmit(event: FormEvent<HTMLFormElement>) {
    // event.preventDefault();
    // console.log(activity);
    // closeForm();
    createOrEdit(activity);
  }

  function handleInputChange(
    event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) {
    const { name, value } = event.target;
    setActivity({ ...activity, [name]: value });
  }

  return (
    <Form onSubmit={handleSubmit} autoComplete="off">
      <Form.Group controlId="formTitle">
        <Form.Control
          type="text"
          placeholder="Title"
          value={activity.title}
          name="title"
          onChange={handleInputChange}
        />
      </Form.Group>
      <Form.Group controlId="formDescription">
        <Form.Control
          as="textarea"
          placeholder="Description"
          value={activity.description}
          name="description"
          onChange={handleInputChange}
        />
      </Form.Group>
      <Form.Group controlId="formCategory">
        <Form.Control
          type="text"
          placeholder="Category"
          value={activity.category}
          name="category"
          onChange={handleInputChange}
        />
      </Form.Group>
      <Form.Group controlId="formDate">
        <Form.Control
          type="text"
          placeholder="Date"
          value={activity.date}
          name="date"
          onChange={handleInputChange}
        />
      </Form.Group>
      <Form.Group controlId="formCity">
        <Form.Control
          type="text"
          placeholder="City"
          value={activity.city}
          name="city"
          onChange={handleInputChange}
        />
      </Form.Group>
      <Form.Group controlId="formVenue">
        <Form.Control
          type="text"
          placeholder="Venue"
          value={activity.venue}
          name="venue"
          onChange={handleInputChange}
        />
      </Form.Group>
      <Button variant="primary" type="submit" className="form-submit-button">
        Submit
      </Button>
      <Button
        onClick={closeForm}
        variant="secondary"
        type="button"
        className="form-cancel-button"
      >
        Cancel
      </Button>
    </Form>
  );
}
