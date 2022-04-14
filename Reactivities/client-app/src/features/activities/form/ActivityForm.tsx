import React from "react";
import { Button, Form } from "react-bootstrap";
import { Activity } from "../../../app/models/activity";

interface Props {
  activity: Activity | undefined;
  closeForm: () => void;
}

export default function ActivityForm({ activity, closeForm }: Props) {
  return (
    <>
      <Form>
        <Form.Group controlId="formTitle">
          <Form.Control type="text" placeholder="Title" />
        </Form.Group>
        <Form.Group controlId="formDescription">
          <Form.Control as="textarea" placeholder="Description" />
        </Form.Group>
        <Form.Group controlId="formCategory">
          <Form.Control type="text" placeholder="Category" />
        </Form.Group>
        <Form.Group controlId="formDate">
          <Form.Control type="date" placeholder="Date" />
        </Form.Group>
        <Form.Group controlId="formCity">
          <Form.Control type="text" placeholder="City" />
        </Form.Group>
        <Form.Group controlId="formVenue">
          <Form.Control type="text" placeholder="Venue" />
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
    </>
  );
}
