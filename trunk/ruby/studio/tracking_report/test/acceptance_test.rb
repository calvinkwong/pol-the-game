require "test/unit"

class AcceptanceTest < Test::Unit::TestCase

  def test_one_entry_gives_one_row
    given_searches a_search(text: "any")

    run_report

    report_rows_count_equals 1
  end

  def test_two_searches_on_same_term_are_counted_twice
    given_searches a_search(text: "any"),
                   a_search(text: "any")

    run_report

    report_rows_equals a_row(text: "a_search", count: 2)
  end
  
  def test_different_searches_are_counted_separately
    given_searches a_search(text: "foo"),
                   a_search(text: "foo"),
                   a_search(text: "bar")

    run_report

    report_rows_equals a_row(text: "foo", count: 2),
                       a_row(text: "bar", count: 1)
  end

  def test_click_is_associated_to_an_existing_search
    given_clicks a_click(text: "any")

    run_report

    report_rows_equals a_row(text: "a_search", count: 1, clicks: 1)
  end

  private

  def run_report

  end

  def a_search(values)

  end

  def a_click(values)

  end

  def a_row(values)

  end

  def given_searches(* searches)

  end

  def given_clicks(* clicks)

  end

  def report_rows_count_equals(value)

  end

  def report_rows_equals(* rows)

  end
end