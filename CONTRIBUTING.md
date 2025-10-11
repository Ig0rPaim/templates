# Contributing to Templates

Thank you for your interest in contributing to the templates repository!

## Adding a New Template

### For Project Templates

1. Create a new directory under the appropriate category in `projects/`:
   - `projects/web/` - for web applications (React, Vue, Angular, etc.)
   - `projects/mobile/` - for mobile apps (React Native, Flutter, etc.)
   - `projects/backend/` - for backend/API services (Node.js, Python, Go, etc.)
   - `projects/desktop/` - for desktop applications (Electron, etc.)

2. Name your template directory descriptively (e.g., `react-typescript-app`, `fastapi-rest-api`)

3. Include a README.md in your template directory with:
   - Brief description of the template
   - Technologies and frameworks used
   - Prerequisites (Node.js version, Python version, etc.)
   - Setup instructions
   - Usage examples
   - Any important notes or gotchas

4. Add all necessary files for the template to work

### For Resource Templates

1. Create a new directory under the appropriate category in `resources/`:
   - `resources/configs/` - for configuration files (ESLint, Prettier, tsconfig, etc.)
   - `resources/scripts/` - for utility scripts (deployment, database, etc.)
   - `resources/docs/` - for documentation templates (API docs, README templates)
   - `resources/workflows/` - for CI/CD workflow templates (GitHub Actions, GitLab CI, etc.)

2. Include a README.md explaining:
   - What the resource is for
   - How to use it
   - Any customization options
   - Examples

### General Guidelines

- Keep templates minimal and focused
- Remove any personal or sensitive information
- Use placeholder values for things like API keys, URLs, etc.
- Add comments to explain non-obvious sections
- Test your template before submitting
- Follow existing code style in the repository
- Update the main README.md if adding a new category

## Questions?

If you have questions or need help, please open an issue in the repository.
